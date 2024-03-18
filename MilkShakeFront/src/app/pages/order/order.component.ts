import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {
  loginForm: FormGroup;
  currentYear: number = Date.now();

  constructor( 
    private formBuilder: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    ) {       
        // Initialize the FormGroup with form controls and validation
        this.loginForm = this.formBuilder.group({
          email: ['', Validators.required],
          password: ['', Validators.required]
        });
    }

    ngOnInit(): void {
    }


  login(): void {

  }
}
