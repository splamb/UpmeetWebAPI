import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EventListComponent } from './event-list/event-list.component';
import { FavoriteListComponent } from './favorite-list/favorite-list.component';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: EventListComponent },
  { path: 'detail/:id', component: FavoriteListComponent },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}