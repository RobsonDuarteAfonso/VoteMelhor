import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MessageComponent } from './menssage/message.component';
import { ListBestPoliticalComponent } from './list-best-political/list-best-political.component';
import { TitleComponent } from './title/title.component';
import { TitleHomeComponent } from './title-home/title-home.component';
import { CardPoliticalComponent } from './card-political/card-political.component';
import { ErrorMsgComponent } from './error-msg/error-msg.component';
import { ListPoliticalComponent } from './list-political/list-political.component';
import { LoadingComponent } from './loading/loading.component';

@NgModule({
  declarations: [
    MessageComponent,
    ListBestPoliticalComponent,
    TitleComponent,
    TitleHomeComponent,
    CardPoliticalComponent,
    ErrorMsgComponent,
    ListPoliticalComponent,
    LoadingComponent
  ],
  imports: [
    CommonModule,
    NgbModule
  ],
  exports: [
    MessageComponent,
    ListBestPoliticalComponent,
    TitleComponent,
    TitleHomeComponent,
    CardPoliticalComponent,
    ErrorMsgComponent,
    ListPoliticalComponent,
    LoadingComponent
  ]
})
export class ComponentsModule { }
