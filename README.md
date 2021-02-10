IoT Streaming Use Case
======================

Reference Documents:

[Tutorial: Migrate event data to Azure Synapse Analytics - Azure Event Hubs \|
Microsoft
Docs](https://docs.microsoft.com/en-us/azure/event-hubs/store-captured-data-data-warehouse)

[Tutorial: Create Apache Spark job definition in Synapse Studio - Azure Synapse
Analytics \| Microsoft
Docs](https://docs.microsoft.com/en-us/azure/synapse-analytics/spark/apache-spark-job-definitions#prerequisites)

[Azure Synapse Analytics - Azure Databricks - Workspace \| Microsoft
Docs](https://docs.microsoft.com/en-us/azure/databricks/data/data-sources/azure/synapse-analytics#usage-streaming)

[azure-event-hubs-spark/README.md at master · Azure/azure-event-hubs-spark
(github.com)](https://github.com/Azure/azure-event-hubs-spark/blob/master/README.md)

Main Steps:

1.  Create ADLS Gen2 Data lake

2.  Create Event Hub Namespace & Event Hub

3.  Create .NET application to send events to event hub

4.  Create ADLS Gen2 Instance – In portal select storage account

![](media/c7c979f0eeb18746462724cb1d5bb433.png)

![](media/d3ae417a2044db11f453c8d7d9744f87.png)

On advanced tab – select the hierarchal name space.

![](media/b44384da854d6fa7d3f14085dc228500.png)

Note: [Soft delete for blobs - Azure Storage \| Microsoft
Docs](https://docs.microsoft.com/en-us/azure/storage/blobs/soft-delete-blob-overview)

1.  Create Event Hub Instance setup as streaming source

2.  Search for Event Hubs in Portal

![](media/01bd481393b74f27e14dd3f3ec77d702.png)

1.  Provide Resource Group Name

![](media/81d1abc8bb134b85a79faa8b7d917866.png)

1.  Setup Basics

![](media/e078b02b975eb2b1a33d91a73734c80a.png)

1.  Deploy

![](media/2032b05e0b05c90d2855ca37d634527f.png)

1.  Create Event Hub

![](media/5f3f4806f80dbc26482dda5305e1f141.png)

\-Create Event Hub

![](media/6243aef93fe65643f32ab9db624b3ba9.png)

Select ADLS Gen 2 - & Create a new Storage Container.

![](media/602cf99249c084f3aeb224870bdfcb5a.png)

![](media/d8a3fbbab581f4b4ba1a6c09f231e597.png)

Hit the select button.

![](media/5288000e590476a6ef823fa45d7c22f0.png)

![](media/74bf051215ad3a52bea902afa5bc40eb.png)

Get Connection String

![](media/2fc0e5041068364142e6d5cff8dbd594.png)

![](media/1361ea58518a30cec3e3bd5278d72715.png)

Grab Connection String, we will use it late.

![](media/de858e7f883c66c58fde115df38126b6.png)

Create a Read/Write

1.  Create .NET application to send telemetry data to Azure Event Hub

If Configuring Databricks to consume event:

Create a Databricks Workspace

![](media/244d172a00b85ccc4cba86a7e2a81b94.png)

![](media/8ecc8ab5c742826a500a7a28d6f621b9.png)

[azure-event-hubs-spark/README.md at master · Azure/azure-event-hubs-spark
(github.com)](https://github.com/Azure/azure-event-hubs-spark/blob/master/README.md)

Go to link of maven central

![](media/9dd95790467b0c9d69e8a716b616d0bc.png)

Install on a single node cluster.

![](media/90578036175b2be763d5e198a4c9aa3c.png)

\-Configure Event Hubs Spark Connnector (Databricks or Synapse)

leverage open source project on github

https://github.com/Azure/azure-event-hubs-spark/blob/master/README.md
