import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import * as bcrypt from 'bcryptjs';
import { User } from 'src/app/models/user.model';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

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
          password: ['', [Validators.required, Validators.minLength(8), Validators.pattern(/^(?=.*[A-Z])/)]],
          firstName: ['', Validators.required],
          lastName: ['', Validators.required],
          dob: ['', Validators.required],
        });
    }

    ngOnInit(): void {
    }


  async register(): Promise<void> {
    let password = this.loginForm.get('password')?.value;

    const hashedPassword = await this.hashPassword(password);

    let user = new User();

    user.email = this.loginForm.get('email')?.value;
    user.passwordHash = hashedPassword;
    user.firstName = this.loginForm.get('firstName')?.value;
    user.lastName = this.loginForm.get('lastName')?.value;
    user.dateOfBirth = this.loginForm.get('dob')?.value;

    user.username = 'unused';
    user.createdAt = new Date(Date.now());
    user.updatedAt =  new Date(Date.now());

    console.log(user);

    this.authService.register(user).subscribe(
      (response) => {
        console.log('Response:', response);

        this.router.navigate(["/order"]);
      },
      (error) => {
        console.error('Error:', error);
      });
  }

  async hashPassword(password: string): Promise<string> {
    const saltRounds = 10;
    const hashedPassword = await bcrypt.hash(password, saltRounds);
    return hashedPassword;
  }
}
