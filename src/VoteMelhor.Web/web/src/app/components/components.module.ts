import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MessageComponent } from './menssage/message.component';
import { ListBestPoliticalComponent } from './list-best-political/list-best-political.component';
import { TitleComponent } from './title/title.component';
import { TitleHomeComponent } from './title-home/title-home.component';
import { CardPoliticalComponent } from './card-political/card-political.component';

@NgModule({
  declarations: [
    MessageComponent,
    ListBestPoliticalComponent,
    TitleComponent,
    TitleHomeComponent,
    CardPoliticalComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    MessageComponent,
    ListBestPoliticalComponent,
    TitleComponent,
    TitleHomeComponent
  ]
})
export class ComponentsModule { }
