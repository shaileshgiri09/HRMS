import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  message : any ; 

  constructor(private authService : AuthService, private router : Router){}

  onSubmit(data : any)
  {
    this.authService.logIn(data).subscribe((response : any)=>{
      localStorage.setItem('token', response.token);
      console.log(response);
      if(response==null)
      {
        this.router.navigate(["login"])
        this.message = "Login Details not Found";
      }

    })
  }

}
