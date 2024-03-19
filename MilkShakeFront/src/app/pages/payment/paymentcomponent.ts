import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user.model';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent implements OnInit {
  amount: number = 0;
  redirectUrl: string = this.router.parseUrl("/payment").toString();
  complete: boolean = false;

  currentUser: User = {} as User;
  
  constructor( 
    private router: Router,
    private route: ActivatedRoute
  ) {       
      // Initialize the FormGroup with form controls and validation
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.amount = params['amount'];
      this.complete = params['complete'];
    });

    this.currentUser = new User(JSON.parse(localStorage['currentUser']));
  }
  
  redirect(): void {
    this.router.navigateByUrl('/order');
  }
}
