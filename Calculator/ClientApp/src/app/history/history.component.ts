import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { CalculatorHistory } from '../types';

@Component({
    selector: 'app-history',
    templateUrl: './history.component.html'
})
export class HistoryComponent {
    public calcHistories: CalculatorHistory[];
    public loading: boolean = false;
    public failed: boolean = false;
    public unAuthorized: boolean = false;
    constructor(http: HttpClient, private router: Router, @Inject('BASE_URL') baseUrl: string) {
        if (!this.loggedIn()) {
            router.navigate(["login"]);
        }
        else {
            let token = localStorage.getItem("Token");
            console.log(token);            
            var header = {
                headers: new HttpHeaders()
                    .set('Authorization', `Bearer ${token}`)
            }
            http.get<CalculatorHistory[]>(`${baseUrl}calculator/history`, header).subscribe(res => {
                this.calcHistories = res;
            }, error => {
                if (error.status == 401) {
                    this.unAuthorized = true;
                }
                console.log(error);
            })
        }        
    }
    loggedIn() {
        return localStorage.getItem("isLoggedIn") == "true";
    }
}

