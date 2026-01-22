import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerService } from '@proxy/customers'; 
@Component({
  selector: 'app-user-dashboard',
  standalone: true,
  imports: [CommonModule], 
  templateUrl: './user-dashboard.component.html',
  styleUrl: './user-dashboard.component.scss'
})
export class UserDashboardComponent implements OnInit {

  userName: string = 'Yükleniyor...'; 

 
  constructor(private customerService: CustomerService) {}

  ngOnInit() {
   
    this.customerService.getCurrentUserName().subscribe({
      next: (name) => {
        this.userName = name; 
        console.log("Kullanıcı adı başarıyla çekildi:", name);
      },
      error: (err) => {
        console.error("İsim çekilirken hata oluştu:", err);
        this.userName = 'Kullanıcı'; 
      }
    });
  }
}