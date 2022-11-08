import { NgModule } from '@angular/core';
import { AccountableRoutingModule } from './accountable-routing.module';
import { AccountableComponent } from './accountable.component';
import { SharedModule } from '../shared/shared.module';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    AccountableComponent
  ],
  imports: [
    SharedModule,
    AccountableRoutingModule,
    NgbDatepickerModule
  ]
})
export class AccountableModule { }
