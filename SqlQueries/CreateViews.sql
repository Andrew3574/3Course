use SportDb
go
create or alter view ExcerciseView as
select ExcerciseId, ex.[Name] as Excercise,mus.[Name] as Muscle, ex.[Description] 
from Excercises as ex 
join Muscles as mus on ex.MuscleId=mus.MuscleId
go

go
create or alter view SetExcerciseView as
select setex.Id,s.[Name] as [Set],ex.[Name] as Excercise,ex.[Description],setex.RepeatsNumber,setex.IterationNumber,setex.RepeatsDelay,setex.RestTimeAfter
from SetExcercises as setex
join [Sets] as s on setex.SetId=s.SetId
join Excercises as ex on setex.ExcerciseId=ex.ExcerciseId
go