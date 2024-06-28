import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { LoginComponent } from './login/login.component';
import { EvaluateComponent } from './evaluate/evaluate.component';
import { HistoryComponent } from './history/history.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,        
        LoginComponent,
        EvaluateComponent,
        HistoryComponent,
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', component: EvaluateComponent, pathMatch: 'full' },
            { path: 'login', component: LoginComponent },
            { path: 'history', component: HistoryComponent },
        ])
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
