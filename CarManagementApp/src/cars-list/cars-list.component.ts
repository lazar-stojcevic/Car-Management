import { Component, OnInit } from '@angular/core';
import { Client, Item } from '../app/api/api-reference';
import {MatTableModule} from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-cars-list',
  imports: [MatTableModule, MatIconModule],
  templateUrl: './cars-list.component.html',
  styleUrl: './cars-list.component.scss'
})
export class CarsListComponent implements OnInit {
  constructor(private client: Client) {}

  cars: Item[] = [];

  ngOnInit(): void {
    this.client.getCars(10, 10).subscribe(cars => {
      this.cars = cars.items ?? [];
    });
  }
}
