import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { EvaluateResult } from '../types';

@Component({
    selector: 'app-evaluate',
    templateUrl: './evaluate.component.html',
})
export class EvaluateComponent {
    public input: string;
    public evaluated: boolean = false;
    public evaluating: boolean = false;
    public evalResult: EvaluateResult;
    private baseURL: string;
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseURL = baseUrl;
    }
    eval() {
        this.evaluated = false;
        this.evaluating = true;
        this.http.get<EvaluateResult>(`${this.baseURL}calculator/evaluate?input=${encodeURIComponent(this.input)}`).subscribe(res => {
            this.evalResult = res;
            this.evaluated = true;
            this.evaluating = true;
        }, error => {
            //console.log(error);
            this.evalResult = error.error;
            this.evaluated = true;
            this.evaluating = true;
        });
    }
    onInputChange(event: Event) {
        this.input = (event.target as HTMLInputElement).value;
    }
}
