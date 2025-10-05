import { Component } from '@angular/core';
import { CommonModule, NgIf, NgFor } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CuttingDownMasterService } from '../../../services/CuttingDownMasterService/cutting-down-master';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Router } from '@angular/router';  // <-- Import Router here
import { CuttingDownSearchDto } from '../../../Interfaces/CuttingDownMasterInterfaces/CuttingDownSearchDto';
import { CuttingDownResultDto } from '../../../Interfaces/CuttingDownMasterInterfaces/CuttingDownResultDto';
import { CuttingDownSearchResultDto } from '../../../Interfaces/CuttingDownMasterInterfaces/cuttingdownsearchResultDto';

@Component({
  selector: 'app-cutting-down-master',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, RouterModule],
  templateUrl: './cutting-down-master.html',
  styleUrl: './cutting-down-master.css'
})
export class CuttingDownMaster {
  searchDto: CuttingDownSearchDto = {
    pageNumber: 1,
    pageSize: 4
  };

  searchResult: CuttingDownSearchResultDto | null = null;
  errorMessage = '';
  isLoading = false;
  Math = Math;

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

  constructor(
    private masterService: CuttingDownMasterService,
    private router: Router   // <-- Inject Router here
  ) {}

  onSearch() {
    this.isLoading = true;
    this.errorMessage = '';
    this.searchResult = null;

    this.masterService.searchTickets(this.searchDto).subscribe({
      next: (res) => {
        this.searchResult = res;
        this.isLoading = false;
      },
      error: (err) => {
        this.errorMessage = 'Search failed.';
        console.error(err);
        this.isLoading = false;
      }
    });
  }

  goToPage(page: number) {
    this.searchDto.pageNumber = page;
    this.onSearch();
  }

  exportToExcel() {
    this.masterService.exportSearchResults(this.searchDto).subscribe({
      next: (blob) => {
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = 'CuttingDownSearchResults.xlsx';
        a.click();
        window.URL.revokeObjectURL(url);
      },
      error: (err) => {
        this.errorMessage = 'Export failed.';
        console.error(err);
      }
    });
  }

  // New method to navigate to details page
  goToDetails(id: number) {
    this.router.navigate(['/getbyidcuttingdownmaster', id]);
  }
}
