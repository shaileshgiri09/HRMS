import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http : HttpClient) { }

  logIn(data :any)
  {
    return this.http.post('https://localhost:7016/api/Auth/SignIn',data);
  }

  register(data : any)
  {
    return this.http.post('',data);
  }
}
