-- �������� ������� "������� ����"
CREATE TABLE �������_���� (
    id INT PRIMARY KEY IDENTITY(1,1), -- �������������������� ��������� ����
    ��� NVARCHAR(20) UNIQUE NOT NULL, -- ���������� ���� ��� ���
    ��� NVARCHAR(50) NOT NULL,
    ������� NVARCHAR(50) NOT NULL,
    ����_�������� DATE NOT NULL,
    ����� NVARCHAR(100) NOT NULL,
    ������� NVARCHAR(20) NOT NULL,
    email NVARCHAR(100)
);

-- �������� ������� "����������� ����"
CREATE TABLE �����������_���� (
    id INT PRIMARY KEY IDENTITY(1,1), -- �������������������� ��������� ����
    ��� NVARCHAR(20) UNIQUE NOT NULL, -- ���������� ���� ��� ���
    �������� NVARCHAR(100) NOT NULL,
    ����� NVARCHAR(100) NOT NULL,
    ������� NVARCHAR(20) NOT NULL,
    email NVARCHAR(100)
);

-- �������� ������� "���������"
CREATE TABLE ��������� (
    id INT PRIMARY KEY IDENTITY(1,1), -- �������������������� ��������� ����
    ��� NVARCHAR(50) NOT NULL,
    ������� NVARCHAR(50) NOT NULL,
    ����_�������� DATE NOT NULL,
    ����� NVARCHAR(100) NOT NULL,
    ������� NVARCHAR(20) NOT NULL,
    email NVARCHAR(100),
    id_��������_���� INT NOT NULL,
    FOREIGN KEY (id_��������_����) REFERENCES �������_����(id)
);

-- �������� ������� "������������"
CREATE TABLE ������������ (
    id INT PRIMARY KEY IDENTITY(1,1), -- �������������������� ��������� ����
    ��������_id INT NOT NULL,
    ��� NVARCHAR(50) NOT NULL,
    ����� NVARCHAR(100) NOT NULL,
    ������� DECIMAL(10, 2) NOT NULL,
    ��������� DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (��������_id) REFERENCES �������_����(id) ON DELETE CASCADE
);

-- �������� ������� "������������ ��������"
CREATE TABLE ������������_�������� (
    id INT PRIMARY KEY IDENTITY(1,1), -- �������������������� ��������� ����
    ��������_id INT NOT NULL,
    ��� NVARCHAR(50) NOT NULL,
    ����� NVARCHAR(50) NOT NULL,
    ������ NVARCHAR(50) NOT NULL,
    ���_������� INT NOT NULL,
    ��������� DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (��������_id) REFERENCES �������_����(id) ON DELETE CASCADE
);

-- �������� ������� "�����"
CREATE TABLE ����� (
    id INT PRIMARY KEY IDENTITY(1,1), -- �������������������� ��������� ����
    ��������_id INT NOT NULL,
    ����� DECIMAL(18, 2) NOT NULL,
    ���_������ NVARCHAR(50) NOT NULL,
    ����_������ DATE NOT NULL,
    ������ NVARCHAR(50) NOT NULL,
    FOREIGN KEY (��������_id) REFERENCES �������_����(id) ON DELETE CASCADE
);

-- ���������� ������� �� ���� ��� ��� ������� "�������_����"
CREATE INDEX IX_���_�������_���� ON �������_����(���);

-- ���������� ������� �� ���� ��� ��� ������� "�����������_����"
CREATE INDEX IX_���_�����������_���� ON �����������_����(���);
