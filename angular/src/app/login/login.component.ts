import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  // Router'ı HTML içinde (routerLink gibi) kullanmayacak olsan bile 
  // genel uyumluluk için RouterModule eklemek sağlıklıdır.
  imports: [CommonModule, RouterModule], 
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  // Router'ı sınıf içinde kullanabilmek için constructor'da tanımlıyoruz
  constructor(private router: Router) {}

  onLogin() {
    // Burada ileride backend doğrulaması (ABP.io API call) yapacaksın.
    // Şimdilik doğrudan yönlendirme yapıyoruz:
    this.router.navigate(['/user-dashboard']);
  }
}