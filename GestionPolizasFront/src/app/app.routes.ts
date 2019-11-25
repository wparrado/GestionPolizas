import { AdicionPolizaComponent } from './adicion-poliza/adicion-poliza.component';
import { PolizaComponent } from './poliza/poliza.component';
import { Routes, RouterModule } from '@angular/router';

const APP_ROUTES: Routes = [
  { path: 'polizas', component: PolizaComponent },
  { path: 'add-policy', component: AdicionPolizaComponent}
];

export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES);
