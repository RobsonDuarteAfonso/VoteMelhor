import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { LoginComponent } from './login/login.component';
import { MessageComponent } from './menssage/message.component';


@NgModule({
  declarations: [
    MessageComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule
  ],
  exports: [
    MessageComponent,
    LoginComponent
  ]
})
export class ComponentsModule { }
