import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MilkshakeConfig } from 'src/app/models/config.model';
import { User } from 'src/app/models/user.model';
import { AuthService } from 'src/app/services/auth.service';
import { ShakeService } from 'src/app/services/shake.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  currentYear: number = Date.now();
  loginFailed: boolean = false;
  config: MilkshakeConfig = {} as MilkshakeConfig;

  constructor( 
    private formBuilder: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private authService: AuthService,
    private shakeService: ShakeService
    ) {       
        // Initialize the FormGroup with form controls and validation
        this.loginForm = this.formBuilder.group({
          email: ['', [Validators.required, Validators.email]],
          password: ['', [Validators.required, Validators.minLength(8), Validators.pattern(/^(?=.*[A-Z])/)]]
        });
    }

    ngOnInit(): void {
      this.shakeService.getConfig().subscribe(
        (response) => {
          console.log('Response:', response);
          this.config = response;
          localStorage.setItem('config', JSON.stringify(this.config));
        },
        (error) => {
          console.error('Error:', error);
        });
    }


  async login(): Promise<void> {
    let email = this.loginForm.get('email')?.value,
        password = this.loginForm.get('password')?.value;

    this.authService.login(email, password).subscribe(
      (response) => {
        console.log('Response:', response);

        let user: User = response;
        localStorage.setItem('currentUser', JSON.stringify(user));
        
        if (response !== null) {
          this.router.navigate(["/order"]);
        } else {
          this.loginFailed = true;
        }
      },
      (error) => {
        console.error('Error:', error);
        this.loginFailed = true;
      });
  }
}
