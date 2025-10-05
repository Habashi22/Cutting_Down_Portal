
import { CuttingDownResultDto } from '../CuttingDownMasterInterfaces/CuttingDownResultDto';

export interface CuttingDownSearchResultDto {
  totalCount: number;
  pageNumber: number;
  pageSize: number;
  results: CuttingDownResultDto[];
}