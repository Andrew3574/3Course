use SportDb
set nocount on

declare @Symbol CHAR(52)= 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz',
		@i int,
		@RowCount int,
		@NumberUsers int,
		@NumberSets int,
		@NumberSetExcercises int,
		@MinNumSymbols int,
		@MaxNumSymbols int,
		@NameLimit int,
		@Login varchar(32),
		@Password varchar(20),
		@Email varchar(32),
		@Position int,
		@PasswordLimit int,
		@SetName varchar(32),
		@MinUserId int,
		@MaxUserId int,
		@UserId int,
		@ExcerciseId int,
		@SetId int,
		@TimeDelay time,
		@RestTimeAfter time,
		@Minute int,
		@Second int

set @NumberUsers = 500
set @NumberSets = 20000
set @NumberSetExcercises = 20000

set @MinNumSymbols = 4
set @MaxNumSymbols = 20


begin transaction

--

	select @i=0 from dbo.Users with (tablockx) where 1=0

		set @RowCount=1
		set @PasswordLimit=5
		set @MinNumSymbols=3
		set @MaxNumSymbols=18

		while @RowCount<=@NumberUsers
		begin
			
			set @NameLimit=@MinNumSymbols+RAND()*(@MaxNumSymbols-@MinNumSymbols) -- имя от 3 до 32 символов
			set @i=1
			set @Login=''
			set @Password=''
			set @Email=''

			while @i<=@NameLimit
			begin				
				set @Position=Rand()*52
				set @Login = @Login + SUBSTRING(@Symbol,@Position,1)			
				set @i=@i+1				
			end

			set @Email=@Login + '@gmail.com'
			set @i=0

			while @i<=@PasswordLimit
			begin				
				set @Position=RAND()*52
				set @Password=@Password+SUBSTRING(@Symbol,@Position,1)
				set @i=@i+1
			end
			set @i=0			

			insert into dbo.Users ([Login],[Password],[Email]) select @Login,@Password,@Email

			set @RowCount+=1
		end

--
	
	select @i=0 from [Sets] with (tablockx) where 1=0
		
		set @RowCount=1
		set @MinUserId=(select Min(Users.UserId) from Users)
		set @MaxUserId=(select Max(Users.UserId) from Users)

		while @RowCount<=@NumberSets
		begin
			
			set @NameLimit = @MinNumSymbols+RAND()*(@MaxNumSymbols-@MinNumSymbols)
			set @i=0
			set @SetName=''

			while @i<=@NameLimit
			begin				
				set @Position=RAND()*52
				set @SetName=@SetName+SUBSTRING(@Symbol,@Position,1)
				set @i+=1
			end

			insert into dbo.[Sets]([Name],[UserId]) select @SetName, (@MinUserId+Rand()*(@MaxUserId-@MinUserId))

			set @RowCount+=1
		end

--

		select @i=0 from SetExcercises with (tablockx) where 1=0

		set @i=1
		set @RowCount=1

		while @RowCount<=@NumberSetExcercises
		begin

		set @ExcerciseId = (select top 1 ExcerciseId from Excercises order by NEWID())
		set @SetId = (select top 1 SetId from [Sets] order by NEWID())
		set @TimeDelay = '00:05:00'
		set @RestTimeAfter = '00:08:00'

		insert into SetExcercises(ExcerciseId,SetId,RepeatsNumber,IterationNumber,RepeatsDelay,RestTimeAfter) select @ExcerciseId,@SetId,Rand()*4+1,RAND()*15+1,@TimeDelay,@RestTimeAfter
		
		set @RowCount+=1
		end



commit transaction
