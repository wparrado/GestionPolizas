import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { PolizaService } from './../services/poliza.service';
import { Component, OnInit } from '@angular/core';
import { PolicyModel } from '../policy-model';

@Component({
  selector: 'app-adicion-poliza',
  templateUrl: './adicion-poliza.component.html',
  styleUrls: ['./adicion-poliza.component.css']
})
export class AdicionPolizaComponent implements OnInit {

  policyModel: PolicyModel;

  constructor(private polizaService: PolizaService, private router: Router) { 

  }

  ngOnInit() {
  }

  onSubmit(formData) {
    this.polizaService.createPolicy(formData);
  }
}
