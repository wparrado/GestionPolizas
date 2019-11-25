import { Router } from '@angular/router';
import { PolizaService } from './../services/poliza.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-poliza',
  templateUrl: './poliza.component.html',
  styleUrls: ['./poliza.component.css']
})
export class PolizaComponent implements OnInit {

  policies: any[] = [];
  constructor(private polizaService: PolizaService, private router: Router)
  {
    this.polizaService.getPolices()
        .subscribe((data: any) => {
          this.policies = data.resultObject;
        });
  }

  ngOnInit() {
  }

  addPolicy() {
    this.router.navigate(['add-policy']);
  }
}
