import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component'; 
import { UserDashboardComponent } from './user-dashboard/user-dashboard.component';

export const appRoutes: Routes = [
 { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent }, // Artık senin şık tasarımın görünecek!

  {
    path: 'user-dashboard',
    component: UserDashboardComponent,
  },
  
  {
    path: 'books',
    loadComponent: () => import('./books/books.component').then(m => m.BooksComponent),
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(m => m.createRoutes()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(m => m.createRoutes()),
  },
  {
    path: 'tenant-management',
    loadChildren: () => import('@abp/ng.tenant-management').then(m => m.createRoutes()),
  },
  {
    path: 'setting-management',
    loadChildren: () => import('@abp/ng.setting-management').then(m => m.createRoutes()),
  },
];