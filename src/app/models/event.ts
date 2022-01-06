export class Event{
	constructor(
	public eventID: Number,
	public date: Date,
	public location: String,
	public poster: String,
    public eventName: String,
    public description: String
	){ }
}