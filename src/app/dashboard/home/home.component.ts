import { Component, OnInit } from '@angular/core';
import { GardenBed } from '../models/gardenbed.interface';
import { DashboardService } from '../services/dashboard.services';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  gardenBeds: GardenBed[] = [];

  constructor(private dashboardService: DashboardService) { }

  ngOnInit() {

    this.dashboardService.getGardenBeds().subscribe((gardenBeds: GardenBed[]) => { this.gardenBeds = gardenBeds; },
      error => {
        alert('Error getting garden beds?');
      });

  }

}
