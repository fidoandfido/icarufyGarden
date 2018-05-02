import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RootComponent } from './root/root.component';
import { AuthGuard } from '../auth.gaurd';
import { SettingsComponent } from './settings/settings.component';

export const dashboardRouting: ModuleWithProviders = RouterModule.forChild([
  {
      path: 'dashboard',
       component: RootComponent, canActivate: [AuthGuard],

      children: [
        { path: '', component: HomeComponent },
        { path: 'home',  component: HomeComponent },
        { path: 'settings',  component: SettingsComponent },
      ]
    }
]);
