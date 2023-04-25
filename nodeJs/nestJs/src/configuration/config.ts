const config = () => { return {
  general: {
    productionMode: process.env.PRODUCTION_MODE || 'true',
    port: parseInt(process.env.APPLICATION_CENTER_PORT || '3000') || 3000,
    bmsMode: process.env.APPLICATION_CENTER_MODE || 'all',
    statisticVariables: process.env.APPLICATION_CENTER_STATISTIC_VARIABLES || 'VoltageList:max|min|diff,TemperatureList:max|min|diff,PressureList:max|min'
  },
  kafka: {
    bmsNormalMsgKafkaTopic: process.env.APPLICATION_CENTER_BMS_NORMAL_KAFKA_TOPIC || 'bms-telemetry',
    bmsLostMsgKafkaTopic: process.env.APPLICATION_CENTER_BMS_LOST_KAFKA_TOPIC || 'bms-testament'
  },
  database: {
    dbProtocol: process.env.DB_PROTOCOL || 'http',
    dbAuthority: process.env.DATABASE_CONNECTOR_SERVICE_URL || 'localhost:8088',
    dbAPIVersion: process.env.DB_CONNECTOR_API_VERSION || '/api/v5',
    dbPackInfoCollectionName: process.env.PACK_INFO_COLLECTION_NAME || 'etl-app-center-pack-info',
    dbHistoricalStatusCollectionName: process.env.HISTORICAL_STATUS_COLLECTION_NAME || 'etl-app-center-historical-status',
    dbHistoricalFaultCollectionName: process.env.HISTORICAL_FAULT_COLLECTION_NAME || 'etl-app-center-historical-fault'
  }
}};

export default config;
