import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import * as jspdf from 'jspdf';
import { ShakeService } from 'src/app/services/shake.service';
import { EmailService } from 'src/app/services/email.service';


@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent implements OnInit {
  amount: number = 0;
  redirectUrl: string = this.router.parseUrl("/payment").toString();
  complete: boolean = false;
  invoiceAmount: number = 0;
  orderId: number = 0;

  currentUser: User = {} as User;
  
  constructor( 
    private router: Router,
    private route: ActivatedRoute,
    private shakeService: ShakeService,
    private emailService: EmailService
  ) {       
      // Initialize the FormGroup with form controls and validation
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.amount = params['amount'];
      this.complete = params['complete'];
    });

    this.currentUser = new User(JSON.parse(localStorage['currentUser']));

    if (this.complete) {
      this.shakeService.getOrderByUserId(this.currentUser.userId).subscribe(
        (response) => {
          console.log('Response:', response);
          
          this.invoiceAmount = response[response.length-1].totalAmount;
          this.orderId = response[response.length-1].orderId!;

          this.generateConfirmation();
          this.generateInvoice();
        },
        (error) => {
          console.error('Error:', error);
        });
    }
  }

  generateInvoice(): void {
    const doc = new jspdf.jsPDF();
    const currentDate = new Date().toLocaleDateString();
    const customerName = `${this.currentUser.firstName} ${this.currentUser.lastName}`;
    const purchaseDetails = `Product Name: Milkshakes\nPrice: $${this.invoiceAmount}`;
    const paymentAmount = this.invoiceAmount;

    const pdfContent = `
      <h1>Payment Receipt</h1>
      <p><strong>Date:</strong> ${currentDate}</p>
      <p><strong>Customer Name:</strong> ${customerName}</p>
      <p><strong>Purchase Details:</strong></p>
      <p>${purchaseDetails}</p>
      <p><strong>Payment Amount:</strong> $${paymentAmount.toFixed(2)}</p>
      <p>Thank you for your purchase!</p>
    `;
  
    doc.html(pdfContent, {
      callback: (doc) => {
        const pdfBlob = doc.output('blob');
        const formData = new FormData();
        formData.append('pdfFile', pdfBlob, 'payment-receipt.pdf');

        this.emailService.sendEmailWithAttachment(this.currentUser.email, formData)
            .subscribe((response) => {
              console.log('Email sent successfully:', response);
            }, (error) => {
              console.error('Error sending email:', error);
            });
      }
    });
  }

  generateConfirmation(): void {
    const doc = new jspdf.jsPDF();
    const currentDate = new Date().toLocaleDateString();
    const customerName = `${this.currentUser.firstName} ${this.currentUser.lastName}`;
    const orderDetails = `Order ID: ${this.orderId}\nProduct Name: Milkshakes\nPrice: $${this.invoiceAmount}`;
    
    const pdfContent = `
      <h1>Order Confirmation</h1>
      <p><strong>Date:</strong> ${currentDate}</p>
      <p><strong>Customer Name:</strong> ${customerName}</p>
      <p><strong>Order Details:</strong></p>
      <p>${orderDetails}</p>
      <p>Thank you for your order!</p>
    `;
  
    doc.html(pdfContent, {
      callback: (doc) => {
        const pdfBlob = doc.output('blob');
        const formData = new FormData();
        formData.append('pdfFile', pdfBlob, 'order-confirmation.pdf');
  
        this.emailService.sendEmailWithAttachment(this.currentUser.email, formData)
            .subscribe((response) => {
              console.log('Email sent successfully:', response);
            }, (error) => {
              console.error('Error sending email:', error);
            });
      }
    });
  }
  
  
  redirect(): void {
    this.router.navigateByUrl('/order');
  }
}
