import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CustomerService } from '@proxy/customer.service'; // Proxy yolun

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  model = {
    name: '',
    surname: '',
    phone: ''
  };

  constructor(
    private customerService: CustomerService,
    private router: Router
  ) {}

  onRegister() {
  
    if (this.model.phone.length === 11) {
      this.customerService.register(
        this.model.name, 
        this.model.surname, 
        this.model.phone
      ).subscribe({
        next: (result) => {
          if (result) {
            alert("Kayıt başarılı! Şimdi numaranızla giriş yapabilirsiniz.");
            this.router.navigate(['/login']); 
          }
        },
        error: (err) => {
          console.error("Kayıt hatası:", err);
          alert("Kayıt başarısız: " + (err.error?.message || "Bir hata oluştu"));
        }
      });
    } else {
      alert("Lütfen 11 haneli telefon numaranızı girin.");
    }
  }
}