import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginFormComponent } from './login-form/login-form.component';
import { FormsModule } from '@angular/forms';
import { accountRouting } from './account.routing';
import { SharedModule } from '../shared/modules/shared.module';
import { RegistrationFormComponent } from './registration-form/registration-form.component';
import { EmailValidatorDirective } from '../directives/email.validator.directive';
import { UserService } from '../shared/services/user.service';

@NgModule({
  imports: [CommonModule, FormsModule, accountRouting, SharedModule],
  declarations: [RegistrationFormComponent, EmailValidatorDirective, LoginFormComponent],
  providers: [UserService]
})
export class AccountModule { }
