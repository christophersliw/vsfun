import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { HeroDetailComponent } from './components/app/hero-detail.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { HeroesComponent } from './components/app/heroes.component';
import { DashboardComponent } from './components/app/dashboard.component';
@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
       HeroDetailComponent,
       HeroesComponent,
       DashboardComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            {
                path: '',
                redirectTo: '/dashboard',
                pathMatch: 'full'
              },
              {
                path: 'detail/:id',
                component: HeroDetailComponent
              },
            {
                path: 'heroes',
                component: HeroesComponent
              },
              {
                path: 'dashboard',
                component: DashboardComponent
              }
          
        ])
    ]
})
export class AppModuleShared {
}
