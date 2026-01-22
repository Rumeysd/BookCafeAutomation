import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from '@abp/ng.core'; 

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, RouterModule], 
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  constructor(
    private router: Router, 
    private authService: AuthService
  ) {}

  onLogin() {
    // HTML'deki input'tan telefon numarasını alıyoruz
    const phoneInput = document.getElementById('phoneInput') as HTMLInputElement;
    const phone = phoneInput ? phoneInput.value : '';

    if (phone.length === 11) {
 
      this.authService.login({
        username: phone, 
        password: phone,
        rememberMe: true
      }).subscribe({
        next: () => {
          // Giriş başarılı! ABP token'ı sakladı, şimdi dashboard'a uçalım
          console.log("Giriş başarılı, yönlendiriliyor...");
          this.router.navigate(['/user-dashboard']);
        },
        error: (err) => {
          // Hata durumunda (yanlış numara vb.) kullanıcıyı bilgilendir
          console.error("Giriş hatası:", err);
          alert("Giriş yapılamadı. Lütfen numaranızı kontrol edin.");
        }
      });
    } else {
      alert("Lütfen 11 haneli telefon numaranızı girin.");
    }
  }
}