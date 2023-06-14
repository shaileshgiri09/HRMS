import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  constructor(private authService : AuthService, private router : Router){}

  onSubmit(data : any)
  {
    this.authService.register(data).subscribe((response)=>{
      this.router.navigate(['']);
    });
  }

}
