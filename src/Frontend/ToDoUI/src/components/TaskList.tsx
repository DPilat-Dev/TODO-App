import TaskItem from "./TaskItem";

interface Props {}

const TaskList = (props : Props) => {
    return(
        <div>
            <TaskItem />
            <TaskItem />
        </div>
    );
}

export default TaskList;