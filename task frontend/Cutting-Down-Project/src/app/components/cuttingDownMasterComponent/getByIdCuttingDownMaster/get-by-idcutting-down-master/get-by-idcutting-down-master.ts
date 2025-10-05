import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { CuttingDownResultDto } from '../../../../Interfaces/CuttingDownMasterInterfaces/CuttingDownResultDto';
import { CuttingDownMasterService } from '../../../../services/CuttingDownMasterService/cutting-down-master';

@Component({
  selector: 'app-get-by-idcutting-down-master',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './get-by-idcutting-down-master.html',
  styleUrls: ['./get-by-idcutting-down-master.css']
})
export class GetByIdcuttingDownMaster implements OnInit {
  ticketId: number | null = null;
  selectedTicket: CuttingDownResultDto | null = null;
  errorMessage = '';
  isLoading = false;

  constructor(
    private masterService: CuttingDownMasterService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    // Get the ID from the route parameter
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.ticketId = +id;
        this.getTicketById();
      }
    });
  }

  getTicketById() {
    if (!this.ticketId || this.ticketId <= 0) {
      this.errorMessage = 'Invalid Ticket ID.';
      this.selectedTicket = null;
      return;
    }

    this.isLoading = true;
    this.errorMessage = '';
    this.selectedTicket = null;

    this.masterService.getTicketById(this.ticketId).subscribe({
      next: (res) => {
        this.selectedTicket = res;
        this.isLoading = false;
      },
      error: (err) => {
        this.errorMessage = `Failed to load ticket with ID ${this.ticketId}.`;
        console.error(err);
        this.isLoading = false;
      }
    });
  }
}
