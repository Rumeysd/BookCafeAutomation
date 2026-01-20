import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { InternetConnectionStatusComponent, LoaderBarComponent } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-root',
  standalone: true, // Standalone olduğunu belirttik
  imports: [
    RouterOutlet, // Sayfalar arası geçiş için şart
    LoaderBarComponent, // Sayfa yüklenirken üstte çıkan bar
    InternetConnectionStatusComponent // İnternet kesilince çıkan uyarı
  ],
  template: `
    <abp-loader-bar />

    <router-outlet></router-outlet>

    <abp-internet-status />
  `,
})
export class AppComponent {}
