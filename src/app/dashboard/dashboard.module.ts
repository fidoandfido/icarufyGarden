import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/modules/shared.module';
import { dashboardRouting } from './dashboard.routing';
import { HomeComponent } from './home/home.component';
import { RootComponent } from './root/root.component';
import { SettingsComponent } from './settings/settings.component';
import { AuthGuard } from '../auth.gaurd';
import { DashboardService } from './services/dashboard.services';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    dashboardRouting,
    SharedModule,
  ],
  declarations: [HomeComponent, RootComponent, SettingsComponent],
  exports: [],
  providers: [AuthGuard, DashboardService]
})
export class DashboardModule { }
