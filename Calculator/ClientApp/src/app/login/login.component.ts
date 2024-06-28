import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { User } from '../types';
import { Router } from '@angular/router';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
})
export class LoginComponent {
    public email: string;
    public password: string;
    public loaded: boolean = false;
    public loading: boolean = false;
    private baseURL: string;
    public loginResult: User;
    public ErrorMessage: string;
    public IsInvalid: boolean = false;
    constructor(private http: HttpClient, private router: Router, @Inject('BASE_URL') baseUrl: string) {
        this.baseURL = baseUrl;
    }
    login() {
        this.loaded = false;
        this.loading = true;
        this.ErrorMessage = "";
        this.http.post<User>(`${this.baseURL}auth/login`, { Email: this.email, Password: this.password }).subscribe(res => {
            this.loginResult = res;
            this.loaded = true;
            this.loading = false;
            this.IsInvalid = false;
            localStorage.setItem('isLoggedIn', "true");
            localStorage.setItem('Token', res.AccessToken);
            this.router.navigate(['history']);
        }, error => {
            this.IsInvalid = true;
            console.log(error);
            this.ErrorMessage = error.error;
            this.loaded = true;
            this.loading = false;
        });
    }
    onEmailChange(event: Event) {
        this.email = (event.target as HTMLInputElement).value;
    }
    onPasswordChange(event: Event) {
        this.password = (event.target as HTMLInputElement).value;
    }
}
