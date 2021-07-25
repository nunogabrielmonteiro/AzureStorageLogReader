# AzureStorageLogReader

[![Hits](https://hits.seeyoufarm.com/api/count/incr/badge.svg?url=https%3A%2F%2Fgithub.com%2Fnunomo%2FAzureStorageLogReader&count_bg=%2379C83D&title_bg=%23555555&icon=&icon_color=%23E7E7E7&title=hits&edge_flat=false)](https://hits.seeyoufarm.com)

It is a GUI Windows application (.Net 4.8) that allows to read and export the Azure Storage Log files.  <a href="https://nunogabrielmonteiro.github.io/AzureStorageLogReader/">(Check the Website)</a>

<b>Version 1.3.0.</b>

Updates:

Compiled to run as a 64 bits Application to have more memory addressing space, preventing getting OOM exceptions when loading big logs.

New button to load log files from a folder recursively.

New filter option that allows custom filters:

![Exampple:](https://user-images.githubusercontent.com/31699556/124012160-bf43ff80-d9d8-11eb-9b56-bc697a755b79.png)

<b>Version 1.2.0.</b>

Added support to read logs directly from an Event Hub.

![Load from Event Hub:](https://github.com/nunomo/AzureStorageLogReader/blob/main/images/version_1_2_loadfromeh.png)

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

