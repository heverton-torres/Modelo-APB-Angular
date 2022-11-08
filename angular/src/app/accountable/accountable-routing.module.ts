import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountableComponent } from './accountable.component';

const routes: Routes = [{ path: '', component: AccountableComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountableRoutingModule { }
