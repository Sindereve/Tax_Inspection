-- Создание таблицы "Частные лица"
CREATE TABLE Частные_лица (
    id INT PRIMARY KEY IDENTITY(1,1), -- автоинкрементируемый первичный ключ
    ИНН NVARCHAR(20) UNIQUE NOT NULL, -- уникальное поле для ИНН
    имя NVARCHAR(50) NOT NULL,
    фамилия NVARCHAR(50) NOT NULL,
    дата_рождения DATE NOT NULL,
    адрес NVARCHAR(100) NOT NULL,
    телефон NVARCHAR(20) NOT NULL,
    email NVARCHAR(100)
);

-- Создание таблицы "Юридические лица"
CREATE TABLE Юридические_лица (
    id INT PRIMARY KEY IDENTITY(1,1), -- автоинкрементируемый первичный ключ
    ИНН NVARCHAR(20) UNIQUE NOT NULL, -- уникальное поле для ИНН
    название NVARCHAR(100) NOT NULL,
    адрес NVARCHAR(100) NOT NULL,
    телефон NVARCHAR(20) NOT NULL,
    email NVARCHAR(100)
);

-- Создание таблицы "Работники"
CREATE TABLE Работники (
    id INT PRIMARY KEY IDENTITY(1,1), -- автоинкрементируемый первичный ключ
    имя NVARCHAR(50) NOT NULL,
    фамилия NVARCHAR(50) NOT NULL,
    дата_рождения DATE NOT NULL,
    адрес NVARCHAR(100) NOT NULL,
    телефон NVARCHAR(20) NOT NULL,
    email NVARCHAR(100),
    id_частного_лица INT NOT NULL,
    FOREIGN KEY (id_частного_лица) REFERENCES Частные_лица(id)
);

-- Создание таблицы "Недвижимость"
CREATE TABLE Недвижимость (
    id INT PRIMARY KEY IDENTITY(1,1), -- автоинкрементируемый первичный ключ
    владелец_id INT NOT NULL,
    тип NVARCHAR(50) NOT NULL,
    адрес NVARCHAR(100) NOT NULL,
    площадь DECIMAL(10, 2) NOT NULL,
    стоимость DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (владелец_id) REFERENCES Частные_лица(id) ON DELETE CASCADE
);

-- Создание таблицы "Транспортные средства"
CREATE TABLE Транспортные_средства (
    id INT PRIMARY KEY IDENTITY(1,1), -- автоинкрементируемый первичный ключ
    владелец_id INT NOT NULL,
    тип NVARCHAR(50) NOT NULL,
    марка NVARCHAR(50) NOT NULL,
    модель NVARCHAR(50) NOT NULL,
    год_выпуска INT NOT NULL,
    стоимость DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (владелец_id) REFERENCES Частные_лица(id) ON DELETE CASCADE
);

-- Создание таблицы "Налог"
CREATE TABLE Налог (
    id INT PRIMARY KEY IDENTITY(1,1), -- автоинкрементируемый первичный ключ
    владелец_id INT NOT NULL,
    сумма DECIMAL(18, 2) NOT NULL,
    тип_налога NVARCHAR(50) NOT NULL,
    дата_подачи DATE NOT NULL,
    статус NVARCHAR(50) NOT NULL,
    FOREIGN KEY (владелец_id) REFERENCES Частные_лица(id) ON DELETE CASCADE
);

-- Добавление индекса на поле ИНН для таблицы "Частные_лица"
CREATE INDEX IX_ИНН_Частные_лица ON Частные_лица(ИНН);

-- Добавление индекса на поле ИНН для таблицы "Юридические_лица"
CREATE INDEX IX_ИНН_Юридические_лица ON Юридические_лица(ИНН);
