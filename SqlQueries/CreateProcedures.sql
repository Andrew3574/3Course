create or alter proc InsertExcercise(@Name varchar(32),@Muscle varchar(32), @Description varchar(50) = '')
as
declare @MuscleId int
set @MuscleId = (Select MuscleId from Muscles Where @Muscle = @Name)
begin tran
insert into Excercises select @Name,@MuscleId,@Description
commit tran
go



create or alter proc InsertSet(@Name varchar(32), @User varchar(32))
as
declare @UserId int
set @UserId = (select UserId from Users Where @User = [Login])
begin tran
insert into [Sets] select @Name,@UserId
commit tran
go



create or alter proc InsertSetExcercise(
@Excercise varchar(32),
@Set varchar(32),
@RepeatsNumber int,
@IterationNumber int,
@RepeatsDelay varchar(6),
@RestTimeAfter varchar(6))
as

declare @ExcerciseId int,
@SetId int,
@RepDelayTime time(0),
@RestTime time(0)

set @ExcerciseId = (select ExcerciseId from Excercises Where @Excercise = [Name])
set @SetId = (select SetId from [Sets] Where @Set = [Name])
set @RepDelayTime = (SELECT CAST(STUFF(STUFF(@RepeatsDelay,3,0,':'),6,0,':') AS TIME(0)))
set @RestTime = (SELECT CAST(STUFF(STUFF(@RestTimeAfter,3,0,':'),6,0,':') AS TIME(0)))

begin tran
insert into SetExcercises select @ExcerciseId,@SetId,@RepeatsNumber,@IterationNumber,@RepDelayTime,@RestTime
commit tran
go