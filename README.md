# AzureStorageLogReader

It is a GUI Windows application (.Net 4.7.2 Windows Forms) that allows to read and export the Azure Storage Log files.

<b>Version 1.0.0.</b>

The application allows us to read log files appending the data to the table, using the Add Log files button, it is possible to choose multiple files.

![Select files:](https://github.com/nunomo/AzureStorageLogReader/blob/main/images/AzureStorageLogReader_1.png)

It is possible to choose which columns appear in the grid.

![Choose columns:](https://github.com/nunomo/AzureStorageLogReader/blob/main/images/AzureStorageLogReader_2.png)

And allows to Sort and Filter the grid.

![Filter:](https://github.com/nunomo/AzureStorageLogReader/blob/main/images/AzureStorageLogReader_3.png)

And export data to Excel format.

<b>Version 1.1.0.</b>

This version supports the *.log extension (classic) and the JSON format (preview), more information about the new storage accounts logs here: https://docs.microsoft.com/en-us/azure/storage/blobs/monitor-blob-storage?tabs=azure-portal#creating-a-diagnostic-setting

![Select Mode:](https://github.com/nunomo/AzureStorageLogReader/blob/main/images/version_1_1_selectmode.png)

Now it is also possible to add a connection pane, connect to a SA using the Key or SAS, and load the logs directly from the selected storage account:

![Load logs from SA:](https://github.com/nunomo/AzureStorageLogReader/blob/main/images/version_1_1_loadfromsa.png)
