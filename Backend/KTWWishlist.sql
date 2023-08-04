create database dbKTWWishlist
go

create table Wishlistes (
	WishListid int identity(1,1) primary key,
	packageId int,
	userID int
)
go

create or alter proc proc_AddWishlist (@packageId int, @userID int,@WLId int out)
as
begin
	insert into Wishlistes (packageId,userID) values (@packageID,@userID)
	set @WLId = (select MAX(WishListid) from Wishlistes)
end
go

begin
declare @id int
	exec proc_AddWishlist 1,1,@id out
	print @id
end


create or alter proc proc_DeleteWishList (@WishListid int)
as	
	delete Wishlistes where WishListid = @WishListid
go

exec proc_DeleteWishList 1

create or alter proc proc_GetAllWishList
as
	select * from Wishlistes

exec proc_GetAllWishList
