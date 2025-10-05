import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CuttingDownMasterService } from '../../../services/CuttingDownMasterService/cutting-down-master';
import { AddCuttingDownDto } from '../../../Interfaces/CuttingDownMasterInterfaces/AddCuttingDownDto';

@Component({
  selector: 'app-add-cutting-down',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './add-cutting-down-master.html',
  styleUrl: './add-cutting-down-master.css'
})
export class AddCuttingDownComponent {
 dto: AddCuttingDownDto = {
  channelKey: 0,
  problemTypeKey: 0,
  actualCreatedDate: new Date().toISOString().slice(0, 16), // datetime-local format
  isPlanned: false,
  isGlobal: false,
  createSystemUserID: 1,
  updateSystemUserID: 1,
  impactedCustomers: 0
};

  successMessage = '';
  errorMessage = '';

  problemTypes = [
    { id: 1, name: 'حريق' },
    { id: 2, name: 'ضغط عالى' },
    { id: 3, name: 'استهلاك عالى' },
    { id: 4, name: 'مديونيه' },
    { id: 5, name: 'تلف عداد' },
    { id: 6, name: 'سرقة تيار' },
    { id: 7, name: 'امطار' },
    { id: 8, name: 'كسر ماسورة مياه' },
    { id: 9, name: 'كسر ماسورة غاز' },
    { id: 10, name: 'تحديث واحلال' },
    { id: 11, name: 'صيانه' },
    { id: 12, name: 'كابل مقطوع' },
    { id: 13, name: 'توصيل كابل' }
  ];

  channels = [
    { id: 1, name: 'Source A' },
    { id: 2, name: 'Source B' }
  ];

  constructor(private service: CuttingDownMasterService) {}

  onSubmit() {
    this.service.addManualTicket(this.dto).subscribe({
      next: () => {
        this.successMessage = '✅ Ticket added successfully!';
        this.errorMessage = '';
        // Reset form (optional)
        this.dto = {
          channelKey: 0,
          problemTypeKey: 0,
  actualCreatedDate: new Date().toISOString().slice(0, 16), // datetime-local format
          isPlanned: false,
          isGlobal: false,
          createSystemUserID: 1,
          updateSystemUserID: 1,
          impactedCustomers: 0
        };
      },
      error: () => {
        this.successMessage = '';
        this.errorMessage = '❌ Failed to add ticket.';
      }
    });
  }
}
