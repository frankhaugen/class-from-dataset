## class-from-dataset
A simple tool to use a dataset, (e.g. CSV), to generate a .class file with a class

### Basic functionality
Feed tha program with a dataset it recognizes with headers and some data, (min. 5 lines of data), and it will create a class after doing a "best guess" for which datatype it should use for the diffrent columns, (if it's less than 60% certain, it will deem it a string by default)

### Testing Dataset
While testing, this program uses an astronomical dataset, because it has coloumns of varying types of data.