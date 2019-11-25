import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

// Routes
import { APP_ROUTING } from './app.routes';

// Services

// Components
import { AppComponent } from './app.component';
import { PolizaComponent } from './poliza/poliza.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HttpClientModule } from '@angular/common/http';
import { AdicionPolizaComponent } from './adicion-poliza/adicion-poliza.component';

@NgModule({
  declarations: [
    AppComponent,
    PolizaComponent,
    NavbarComponent,
    AdicionPolizaComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    APP_ROUTING,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
