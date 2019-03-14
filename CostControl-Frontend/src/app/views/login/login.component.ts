import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { GenericService } from '../../generic.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: []
})
export class LoginComponent implements OnInit {

  formLogin: FormGroup;

  constructor(private route: Router, private service: GenericService) { }

  ngOnInit() {
    this.formLogin = new FormGroup({
      'username': new FormControl(null, [Validators.required]),
      'password': new FormControl(null, [Validators.required])
    })
  }

  login(): void {
    
    if(this.formLogin.status === 'INVALID'){
      this.formLogin.get('username').markAsTouched();
      this.formLogin.get('password').markAsTouched();
    } else {
      this.service.getToken(
        this.formLogin.get('username').value, 
        this.formLogin.get('password').value).subscribe(
          data => {
            window.localStorage.setItem('token', data.accessToken);
            this.route.navigate(['/dashboard'])
          }
        )
    }
  }
}
