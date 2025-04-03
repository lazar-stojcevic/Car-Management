import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Client, WeatherForecast } from './api/api-reference';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'CarManagementApp';

  constructor(private client: Client) {
    client.getWeatherForecast().subscribe(res => {
      console.log(res);
    });
  }
}
