export interface CuttingDownResultDto {
  cuttingDownKey: number;
  incidentId: number;
  channelName: string;
  problemTypeName: string;
  createdAt: string;
  endedAt?: string;
  isGlobal: boolean;
  isPlanned: boolean;
  impactedCustomers: number;
}