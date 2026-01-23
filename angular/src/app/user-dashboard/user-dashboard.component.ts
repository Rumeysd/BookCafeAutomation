import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerService } from '@proxy/customer.service'; // Proxy yolunu netleştirdik

@Component({
  selector: 'app-user-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user-dashboard.component.html',
  styleUrl: './user-dashboard.component.scss'
})
export class UserDashboardComponent implements OnInit {

  userName: string = 'Yükleniyor...';

  // Servis adını proxy dosyasındakiyle aynı (CustomerAppService) yapmalısın
  constructor(private customerService: CustomerService) {}

  ngOnInit() {
    this.customerService.getCurrentUserName().subscribe({
      next: (name) => {
        // İsim başarıyla gelirse değişkene ata
        this.userName = name;
      },
      error: (err) => {
        // Konsolda hatayı gör ama sayfadan kovulma
        console.error("İsim çekilemedi, büyük ihtimalle Token gitmiyor:", err);
        
      
        this.userName = "Misafir (Oturum Sorunu)"; 
      }
    });
  }
}