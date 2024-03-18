import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  currentYear: number = Date.now();

  constructor( 
    private formBuilder: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private authService: AuthService,
    ) {       
        // Initialize the FormGroup with form controls and validation
        this.loginForm = this.formBuilder.group({
          email: ['', [Validators.required, Validators.email]],
          password: ['', [Validators.required, Validators.minLength(8), Validators.pattern(/^(?=.*[A-Z])/)]]
        });
    }

    ngOnInit(): void {
    }


  async login(): Promise<void> {
    let email = this.loginForm.get('email')?.value,
        password = this.loginForm.get('password')?.value;

    this.authService.login(email, password).subscribe(
      (response) => {
        console.log('Response:', response);

        if (response) {
          this.router.navigate(["/order"]);
        }
      },
      (error) => {
        console.error('Error:', error);
      });
  }
}
