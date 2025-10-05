export interface CuttingDownSearchDto {
  channelKey?: number;
  problemTypeKey?: number;
  governrateKey?: number;
  fromDate?: string;
  toDate?: string;
  isPlanned?: boolean;
  isGlobal?: boolean;
  isClosed?: boolean;
  networkElementKey?: number;
  networkElementTypeKey?: number;
  filterLevel?: string;    // e.g. "Zone"
  filterKey?: number;
  pageNumber: number;
  pageSize: number;
}