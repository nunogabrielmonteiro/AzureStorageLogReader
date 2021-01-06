# AzureStorageLogReader

[![Hits](https://hits.seeyoufarm.com/api/count/incr/badge.svg?url=https%3A%2F%2Fgithub.com%2Fnunomo%2FAzureStorageLogReader&count_bg=%2379C83D&title_bg=%23555555&icon=&icon_color=%23E7E7E7&title=hits&edge_flat=false)](https://hits.seeyoufarm.com)

It is a GUI Windows application (.Net 4.8) that allows to read and export the Azure Storage Log files.


<b>Version 1.1.0.</b>

This version supports the *.log extension (classic) and the JSON format (preview), more information about the new storage accounts logs here: https://docs.microsoft.com/en-us/azure/storage/blobs/monitor-blob-storage?tabs=azure-portal#creating-a-diagnostic-setting

![Select Mode:](https://github.com/nunomo/AzureStorageLogReader/blob/main/images/version_1_1_selectmode.png)

Now it is also possible to add a connection pane, connect to a SA using the Key or SAS, and load the logs directly from the selected storage account:

![Load logs from SA:](https://github.com/nunomo/AzureStorageLogReader/blob/main/images/version_1_1_loadfromsa.png)

![Send logs to grid:](https://github.com/nunomo/AzureStorageLogReader/blob/main/images/version_1_1_sendtogrid.png)

<b>Version 1.0.0.</b>

The application allows us to read log files appending the data to the table, using the Add Log files button, it is possible to choose multiple files.

![Select files:](https://github.com/nunomo/AzureStorageLogReader/blob/main/images/AzureStorageLogReader_1.png)

It is possible to choose which columns appear in the grid.

![Choose columns:](https://github.com/nunomo/AzureStorageLogReader/blob/main/images/AzureStorageLogReader_2.png)

And allows to Sort and Filter the grid.

![Filter:](https://github.com/nunomo/AzureStorageLogReader/blob/main/images/AzureStorageLogReader_3.png)

And export data to Excel format.

